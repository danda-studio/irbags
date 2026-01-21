<script lang="ts" setup>
import type { ResizebleInputEmits, ResizebleInputProps } from './interfaces';
import { computed } from 'vue';

/**Параметры */
const props = defineProps<ResizebleInputProps>()
/**События */
const emit = defineEmits<ResizebleInputEmits>()

/**Значение */
const value = computed({
    get: () => props.modelValue,
    set: (value: string) => {
        emit('update:modelValue', value)
    }
})

</script>

<template>
    <label class="relative">
        <span class="text-base max-lg:text-xs tracking-tight max-lg:tracking-tighter font-medium">{{ value }}</span>
        <IBGInput v-model="value" class="absolute inset-0" />
    </label>
</template>