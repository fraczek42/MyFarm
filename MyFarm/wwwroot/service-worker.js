self.addEventListener('install', event => {
    console.info('Service worker: Install');
    event.waitUntil(onInstall(event));
    self.skipWaiting();
});

self.addEventListener('activate', event => {
    console.info('Service worker: Activate');
    event.waitUntil(onActivate(event));
    self.clients.claim();
});

self.addEventListener('fetch', event => event.respondWith(onFetch(event)));

const currentVersion = '1.0.0';
const cacheNamePrefix = 'offline-cache-';
const cacheName = `${cacheNamePrefix}${currentVersion}`;
const offlineAssetsInclude = [/\.dll$/, /\.pdb$/, /\.wasm/, /\.html/, /\.js$/, /\.json$/, /\.css$/, /\.woff$/, /\.png$/, /\.jpe?g$/, /\.gif$/, /\.ico$/, /\.blat$/, /\.dat$/, /manifest\.json$/];
const offlineAssetsExclude = [/^service-worker\.js$/];

async function onInstall(event) {
    const urlsToCache = ['./'];
    const cache = await caches.open(cacheName);
    await cache.addAll(urlsToCache);
}

async function onActivate(event) {
    const cacheKeys = await caches.keys();
    await Promise.all(cacheKeys
        .filter(key => key.startsWith(cacheNamePrefix) && key !== cacheName)
        .map(key => caches.delete(key)));
}

async function onFetch(event) {
    if (event.request.url.includes('_framework/blazor-hotreload')) {
        return fetch(event.request);
    }
    const cache = await caches.open(cacheName);
    try {
        const networkResponse = await fetch(event.request);
        await cache.put(event.request, networkResponse.clone());
        return networkResponse;
    } catch (error) {
        const cachedResponse = await cache.match(event.request);
        return cachedResponse || fetch(event.request);
    }
}
