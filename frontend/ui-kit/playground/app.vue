<script lang="ts" setup>
const text = ref();

const items = ref(["System", "Light", "Dark"]);
const value = ref("System");
</script>

<template>
  <div class="text-4xl">
    35px - text-4xl
  </div>
  <div class="text-3xl">
    30px - text-3xl
  </div>
  <div class="text-2xl">
    24px - text-2xl
  </div>
  <div class="text-base">
    20px - text-base
  </div>
  <div class="text-sm">
    16px - text-sm
  </div>
  <div class="text-xs">
    15px - text-xs
  </div>
  <IBGApp>
    <div class="flex flex-col w-max">
      <IBGButton>главная</IBGButton>
      <IBGInput v-model="text" placeholder="поиск" />
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
