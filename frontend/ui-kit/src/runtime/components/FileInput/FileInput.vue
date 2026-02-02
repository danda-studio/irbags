<template>
  <IBGFileUpload :file-delete="false" accept="image/*" icon="ibg:image">
    <template #files-top="{ open }">
      <p
        class="text-black z-10 font-medium absolute top-5 left-5"
        @click="open()"
      >
        заменить
      </p>
    </template>
  </IBGFileUpload>
</template>
