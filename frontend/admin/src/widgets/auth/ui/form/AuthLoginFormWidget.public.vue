<template>
  <IBGForm class="flex justify-between gap-4">
    <IBGFormField class="w-full">
      <IBGInput
        class="w-full"
        placeholder="пароль"
        type="password"
        :maxlength="7"
      />
    </IBGFormField>
    <IBGButton>
      войти
    </IBGButton>
  </IBGForm>
</template>
