import {
  defineNuxtModule,
  createResolver,
  addComponent,
  installModules,
  addTemplate,
} from "@nuxt/kit";
import { readdirSync, statSync, existsSync } from "fs";
import { join } from "path";

export interface ModuleOptions {
  prefix?: string;
}

export default defineNuxtModule<ModuleOptions>({
  meta: {
    name: "irbags-ui",
    configKey: "irbagsUi",
    compatibility: {
      nuxt: "^3.0.0",
    },
  },
  defaults: {
    prefix: "IBG",
  },

  async setup(_options, _nuxt) {
    // 1. Создаем Map модулей
    const modulesToInstall = new Map([
      ["@nuxt/ui", {}], // второй аргумент — это опции модуля
    ]);

    // 2. Set для уже установленных модулей
    const installed = new Set([]);

    // 3. Ставим модуль пакетом
    await installModules(modulesToInstall, installed, _nuxt);

    const resolver = createResolver(import.meta.url);
    const componentsDir = resolver.resolve("./runtime/components");

    const cssPath = resolver.resolve("./runtime/assets/css/main.css");
    _nuxt.options.css.push(cssPath);

    addTemplate({
      filename: "app.config.ts",
      src: resolver.resolve("./runtime/app.config.ts"),
    });

    // Получаем элементы первого уровня
    const entries = readdirSync(componentsDir);

    entries.forEach((entry) => {
      const dirPath = join(componentsDir, entry);

      // Берем только папки
      if (!statSync(dirPath).isDirectory()) return;

      // Ищем .vue файл с таким же именем, как папка
      const componentFile = join(dirPath, `${entry}.vue`);

      if (!existsSync(componentFile)) return;

      const componentName = _options.prefix + entry;

      addComponent({
        name: componentName,
        filePath: componentFile,
      });
    });
  },
});
