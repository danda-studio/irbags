<script lang="ts" setup>
const text = ref();
</script>

<template>
  <IBGApp>
    <div class="flex flex-col w-max">
      <IBGButton />
      <IBGInput v-model="text" />
    </div>
  </IBGApp>
</template>
