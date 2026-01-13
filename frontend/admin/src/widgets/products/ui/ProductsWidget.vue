<script setup lang="ts">
type Product = {
  id: number
  title: string
}

const products: Product[] = Array.from({ length: 16 }, (_, i) => ({
  id: i + 1,
  title: `Товар ${i + 1}`,
}))
</script>

<template>
  <section class="pt-[220px] w-screen px-0 pb-[40px]">
    <div class="grid grid-cols-4 gap-x-0 gap-y-[40px]">
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
  </section>
</template>
