<script lang="ts" setup>
import { computed } from "vue";

/**Параметры */
const props = defineProps({
  /**Значение */
  modelValue: { type: String },
  /**Негтивное состояние */
  isNegative: { type: Boolean, default: false },
});
/**События */
const emit = defineEmits<{
  /**Событие обновления поля инпута */
  "update:modelValue": [value: string];
}>();

/**Поле инпута */
const inputField = computed({
  get: () => props.modelValue,
  set: (value: string) => {
    emit("update:modelValue", value);
  },
});
</script>

<template>
  <UInput
    placeholder="Test"
    v-model="inputField"
    :ui="{ base: { 'text-error': isNegative } }"
  />
</template>
