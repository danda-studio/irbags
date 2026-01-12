<script lang="ts" setup>
const items = ["главная", "товары", "фильтры"];

function onSelect(item: string) {
  if (item === "товары") {
    router.push('/products')
  } else if (item === "главная") {
    router.push('/') // если есть главная страница
  } else if (item === "фильтры") {
    router.push('/filters') // пример, если есть
  }
}
</script>

<template>
  <header class="flex items-center justify-between pt-3 p-5 pb-0 gap-52.5">
    <div class="flex items-center justify-between w-full">
      <IBGInput class="w-full" placeholder="поиск" />
      <IBGRadioGroup
        :ui="{ container: 'hidden', wrapper: 'ml-0', fieldset: 'gap-5', label: 'text-base' }"
        :items="items"
        orientation="horizontal"
      />
    </div>
    <div class="flex items-center justify-between w-full gap-159.5">
      <div class="flex items-center gap-17.75">
        <IBGButton>добавить</IBGButton>
        <IBGButton>удалить</IBGButton>
      </div>
      <IBGButton>выйти</IBGButton>
    </div>
  </header>
</template>
