<script setup lang="ts">
const text = ref("");

const items = ["1", "2", "3"];
const value = ref("1");
</script>

<template>
  <div>Index</div>
  <div class="flex flex-col items-start">
    <IBGButton>Test</IBGButton>
    <IBGInput v-model="text" placeholder="Test" />
    <IBGRadioGroup v-model="value" :items="items" />

    <IBGFileInput class="size-100" />

    <IBGCard class="mt-5">
      <template #default>
        <div class="bg-secondary-500 w-120 h-170.75" />
      </template>
      <template #footer>
        <div>Сумка Kelly</div>
        <div>69 €</div>
      </template>
    </IBGCard>

    <FsdTest />
  </div>
</template>
