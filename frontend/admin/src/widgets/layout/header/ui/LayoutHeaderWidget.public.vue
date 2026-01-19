<script lang="ts" setup>
const { selected } = useNavigation();
/**Элементы навигации */
const navigationItems = Object.keys(routesMap)

</script>

<template>
  <header
    class="fixed top-0 left-0 right-0 z-10 flex items-center justify-between mt-3 m-5 mb-0! gap-52.5 max-lg:m-6 max-lg:mt-5 max-lg:gap-50">
    <div class="flex items-center justify-between w-full">
      <IBGInput class="w-full" placeholder="поиск" />
      <IBGRadioGroup :ui="{ container: 'hidden', wrapper: 'ml-0', fieldset: 'gap-5', label: 'text-base' }"
        :items="navigationItems" orientation="horizontal" v-model="selected" />
    </div>
    <div class="flex items-center justify-between w-full gap-159.5 max-lg:gap-158">
      <div class="flex items-center gap-17.75">
        <IBGButton>добавить</IBGButton>
        <IBGButton>удалить</IBGButton>
      </div>
      <IBGButton>выйти</IBGButton>
    </div>
  </header>
</template>
