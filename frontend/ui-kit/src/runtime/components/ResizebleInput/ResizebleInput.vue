<script lang="ts" setup>
import type { ResizebleInputEmits, ResizebleInputProps } from "./interfaces";
import { computed } from "vue";

/** Параметры */
const props = defineProps<ResizebleInputProps>();
/** События */
const emit = defineEmits<ResizebleInputEmits>();

/** Значение */
const value = computed({
  get: () => props.modelValue,
  set: (value: string) => {
    emit("update:modelValue", value);
  },
});
</script>

<template>
  <label class="relative">
    <span class="text-base opacity-0 max-lg:text-xs tracking-tight max-lg:tracking-tighter font-medium">
      {{ value || placeholder }}
    </span>
    <IBGInput v-model="value" :placeholder="placeholder" class="absolute inset-0" />
  </label>
</template>
