<script lang="ts" setup>
import { useNavigation } from '~/shared/composables/useNavigation'

const { selected, navigationItems } = useNavigation();

</script>

<template>
  <header class="flex items-center justify-between pt-3 p-5 pb-0 gap-52.5">
    <div class="flex items-center justify-between w-full">
      <IBGInput class="w-full" placeholder="поиск" />
      <IBGRadioGroup
        :ui="{ container: 'hidden', wrapper: 'ml-0', fieldset: 'gap-5', label: 'text-base' }"
        :items="navigationItems"
        orientation="horizontal"
        v-model="selected"
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
