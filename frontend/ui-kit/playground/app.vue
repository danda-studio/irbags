<script lang="ts" setup>
import { FileInput } from "../src/runtime/components";

const text = ref();

const items = ref(["System", "Light", "Dark"]);
const value = ref("System");
</script>

<template>
  <IBGApp>
    <div class="flex flex-col w-max">
      <IBGButton>Test</IBGButton>
      <IBGInput v-model="text" placeholder="Test" />
      <IBGRadioGroup v-model="value" :items="items" />
      <FileInput :ui="{ base: 'bg-[#D7D7D7] text-[#D7D7D7]' }" />
    </div>
  </IBGApp>
</template>
