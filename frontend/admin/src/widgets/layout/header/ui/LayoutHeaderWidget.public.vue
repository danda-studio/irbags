<script lang="ts" setup>
const items = ['главная', 'товары', 'фильтры']; 
</script>

<template>
    <header class="flex items-center justify-between p-1.25 gap-22.75">
        <div class="flex items-center justify-between w-full">
            <IBGInput class="w-full" placeholder="поиск" />
            <IBGRadioGroup :ui="{ container: 'hidden', wrapper: 'ml-0', fieldset: 'gap-5', label: 'text-base' }"
                :items="items" orientation="horizontal" />
        </div>
        <div class="flex items-center justify-between w-full gap-117">
            <div class="flex items-center gap-6.75">
                <IBGButton>добавить</IBGButton>
                <IBGButton>удалить</IBGButton>
            </div>
            <IBGButton>выйти</IBGButton>
        </div>
    </header>
</template>