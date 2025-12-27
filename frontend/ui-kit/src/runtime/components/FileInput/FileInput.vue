<template>
  <IBGFileUpload :file-delete="false" accept="image/*" icon="ibg:img-logo">
    <template #files-top="{ removeFile }">
      <p
        class="text-black z-10 font-medium absolute top-5 left-5"
        @click="removeFile()"
      >
        заменить
      </p>
    </template>
  </IBGFileUpload>
</template>
