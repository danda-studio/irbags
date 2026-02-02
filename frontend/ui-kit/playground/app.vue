<script lang="ts" setup>

const text = ref();

const items = ref(["System", "Light", "Dark"]);
const value = ref("0");

const colors = ref<Record<string, string>>({});
const colorIndexes = computed(() => {
  if (!Object.keys(colors.value).length)
    return [{ value: "0" }];
  const items = Object.keys(colors.value).map(item => ({ value: item }));
  if (items.at(-1)?.value) {
    items.push({ value: String(items.length) });
  }
  return items;
});

function filterColors() {
  if (Object.keys(colors.value).length === 1)
    return;
  colors.value = Object.entries(colors.value).reduce((acc, [key, value]) => {
    if (value)
      acc[key] = value;
    return acc;
  }, {} as Record<string, string>);
}

const resizebleInputValue = ref("");
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
      {{ colors }}
      <IBGRadioGroup v-model="value" :items="colorIndexes">
        <template #label="{ item }">
          <IBGInput v-model="colors[item.value]" @focus="value = item.value" @blur="filterColors" />
        </template>
      </IBGRadioGroup>
      <IBGFileInput />

      <IBGCard class="mt-5">
        <template #default>
          <div class="bg-secondary-500 w-120 h-70.75" />
        </template>
        <template #footer>
          <div>сумка kelly</div>
          <div>69 €</div>
        </template>
      </IBGCard>
    </div>
    <IBGResizebleInput v-model="resizebleInputValue" placeholder="поиск" />
    <IBGTextarea />
  </IBGApp>
</template>
