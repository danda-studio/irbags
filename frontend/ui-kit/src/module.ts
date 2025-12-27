import {
  defineNuxtModule,
  createResolver,
  addComponent,
  addTemplate,
  installModules,
} from "@nuxt/kit";
import { readdirSync, statSync, existsSync } from "fs";
import { join } from "path";
import { myAppConfig } from "./app.config";
// import { myAppConfig } from "./runtime/app.config";

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
    const resolver = createResolver(import.meta.url);
    const componentsDir = resolver.resolve("./runtime/components");

    const cssPath = resolver.resolve("./runtime/assets/css/main.css");

    // Подключаем CSS (однократно)
    if (!_nuxt.options.css.includes(cssPath)) {
      _nuxt.options.css.push(cssPath);
    }

    // _nuxt.options.appConfig.ui = myAppConfig.ui
    // _nuxt.options.appConfig = defineAppConfig({

    // })

    // _nuxt.options.appConfig = myAppConfig
    // _nuxt.options.appConfig = {
    //   ..._nuxt.options.appConfig,
    //   ui: { ...myAppConfig.ui },
    // };

    // Инициализируем объекты, не перезаписывая их полностью
    _nuxt.options.colorMode = {
      ...(_nuxt.options.colorMode || {}),
      preference: "light", // устанавливаем светлую тему
    };

    _nuxt.options.icon = {
      ...(_nuxt.options.icon || {}),
      customCollections: [
        {
          prefix: "ibg",
          dir: resolver.resolve("./runtime/assets/icons"),
        },
      ],
    };

    _nuxt.options.ui = {
      prefix: "IBG",
      theme: {
        colors: ["black", "white", "secondary", "error"],
      },
    };

    // 1. Создаем Map модулей
    const modulesToInstall = new Map([["@nuxt/ui", {}]]);

    // 2. Set для уже установленных модулей
    const installed = new Set([]);

    // 3. Ставим модуль пакетом
    await installModules(modulesToInstall, installed, _nuxt);

    _nuxt.options.appConfig = {
      ..._nuxt.options.appConfig,
      ui: { ...myAppConfig.ui, ..._nuxt.options.appConfig.ui },
    };

    // Регистрируем app.config
    // addTemplate({
    //   filename: "app.config.ts",
    //   src: resolver.resolve("./runtime/app.config.ts"),
    // });

    if (!existsSync(componentsDir)) return;

    const entries = readdirSync(componentsDir);

    for (const entry of entries) {
      const dirPath = join(componentsDir, entry);

      if (!statSync(dirPath).isDirectory()) continue;

      const componentFile = join(dirPath, `${entry}.vue`);
      if (!existsSync(componentFile)) continue;

      const name = `${_options.prefix ?? ""}${entry}`;

      addComponent({
        name,
        filePath: componentFile,
        export: "default",
      });
    }
  },
});
