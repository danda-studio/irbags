<script lang="ts" setup>
const { selected } = useNavigation();
/** Элементы навигации */
const navigationItems = Object.keys(routesMap);
/** Поле поиска */
const search = ref();
</script>

<template>
  <header
    class="fixed top-0 left-0 right-0 z-10 flex items-center justify-between mt-4 m-5 mb-0! gap-52.5 max-lg:m-5 max-lg:mt-3 max-lg:gap-38"
  >
    <div class="flex items-center justify-between w-full">
      <IBGResizebleInput v-model="search" class="max-w-114 max-lg:max-w-85" placeholder="поиск" />
      <IBGRadioGroup
        v-model="selected"
        :ui="{ container: 'hidden', wrapper: 'ml-0', fieldset: 'gap-5.5', label: 'text-base max-lg:text-xs' }" :items="navigationItems" orientation="horizontal"
      />
    </div>
    <div class="flex items-center justify-between w-full gap-161 max-lg:gap-119.5">
      <div class="flex items-center gap-17.75 max-lg:gap-14">
        <IBGButton>добавить</IBGButton>
        <IBGButton>удалить</IBGButton>
      </div>
      <IBGButton>выйти</IBGButton>
    </div>
  </header>
</template>
