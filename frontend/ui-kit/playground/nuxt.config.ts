// import { myAppConfig } from "../src/runtime/app.config";

export default defineNuxtConfig({
  modules: ["../src/module.ts", "@nuxt/ui"],
  css: ["../src/runtime/assets/css/main.css"],
  devtools: { enabled: true },
  colorMode: {
    preference: "light",
  },
  ui: {
    prefix: "IBG",
    theme: {
      colors: ["black", "white", "secondary", "error"],
    },
  },
});
