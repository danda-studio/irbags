<script lang="ts" setup>
import { IBGFileInput } from "../src/runtime/components";

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
      <IBGFileUpload
        :file-delete="false"
        accept="image/*"
        icon="i-custom-img-logo"
      >
        <template #files-top="{ removeFile }">
          <p
            class="text-black z-10 opacity-20 font-medium absolute top-5 left-5"
            @click="removeFile()"
          >
            заменить
          </p>
        </template>
      </IBGFileUpload>

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
