<script lang="ts" setup>
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

      <IBGFileInput />

      <IBGCard class="mt-5">
        <template #default>
          <div class="bg-secondary-500 w-120 h-170.75" />
        </template>
        <template #footer>
          <div>Сумка Kelly</div>
          <div>69 €</div>
        </template>
      </IBGCard>
    </div>
  </IBGApp>
</template>
