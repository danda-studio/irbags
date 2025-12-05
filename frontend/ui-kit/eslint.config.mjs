// @ts-check
import antfu from "@antfu/eslint-config";

export default antfu({
  stylistic: {
    indent: 2, // 4, or 'tab'
    quotes: "double", // or 'double'
    semi: true,
  },
  vue: {
    overrides: {
      "vue/no-multiple-template-root": "off",
    },
  },
  formatters: {
    /**
     * Format CSS, LESS, SCSS files, also the `<style>` blocks in Vue
     * By default uses Prettier
     */
    css: true,
    /**
     * Format HTML files
     * By default uses Prettier
     */
    html: true,
    /**
     * Format Markdown files
     * Supports Prettier and dprint
     * By default uses Prettier
     */
    markdown: "prettier",
  },
});
