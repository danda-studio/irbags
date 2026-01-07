export default defineNuxtConfig({
  modules: [
    "@nedelko/nuxt-fsd",
    "@nuxt/eslint",
    "@irbags/ui-kit",
  ],
  srcDir: "src",
  dir: {
    layouts: "app/layouts",
  },
  eslint: {
    config: {
      standalone: false,
    },
  },
  css: ["./src/app/assets/global.css"],
});
