<template>
  <IBGApp>
    <IBGButton class="" />
    {{ colorMode.preference }}
  </IBGApp>
</template>

<script setup>
const colorMode = useColorMode()
</script>
