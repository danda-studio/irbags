export default defineNuxtConfig({
  modules: ["@nedelko/nuxt-fsd", "@nuxt/eslint"],
  srcDir: "src",
  dir: {
    layouts: "app/layouts",
    pages: "app/routes",
    assets: "app/assets",
    middleware: "app/middlewares",
  },
  fsd: {
    rootDir: "src",
    autoImportTSSuffix: ".public",
    autoImportVueSuffix: ".public",
    layers: ["shared", "entities", "features", "widgets", "pages"],
  },
});
