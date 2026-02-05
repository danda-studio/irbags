import type { InputProps } from '#ui/types'

export interface ResizebleInputProps {
  /**Значение */
  modelValue: string | number | null;
  /**Подсказка */
  placeholder: string;
  /**Тип инпута */
  type?: 'text' | 'number' | 'password' | 'email';
  /**Конфиг */
  config?: InputProps;
}

