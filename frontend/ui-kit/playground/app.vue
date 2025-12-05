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
    </div>
  </IBGApp>
</template>
