import type { AppConfig } from "nuxt/schema";

export interface ResizebleInputProps {
  /**Значение */
  modelValue: string | number | null;
  /**Подсказка */
  placeholder: string;
  /**Тип инпута */
  type?: 'text' | 'number' | 'password' | 'email';
  /**Конфиг */
  config?: AppConfig;
}

