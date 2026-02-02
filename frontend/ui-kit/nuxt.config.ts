// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  modules: ["@nuxt/ui", "@nuxt/eslint"],
  ui: {
    prefix: "IBG",
  },
  eslint: {
    config: {
      standalone: false,
    },
  },
});
