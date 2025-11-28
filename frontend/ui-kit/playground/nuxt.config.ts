import { myAppConfig } from "../src/runtime/app.config";

export default defineNuxtConfig({
  modules: ["../src/module"],
  css: ["../src/runtime/assets/css/main.css"],
  devtools: { enabled: true },
  appConfig: myAppConfig,
  colorMode: {
    preference: "light",
  },
});
