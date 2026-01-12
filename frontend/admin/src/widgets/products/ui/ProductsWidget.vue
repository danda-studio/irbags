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
      <div
          v-for="product in products"
          :key="product.id"
          class="h-[748px] bg-gray-300 flex items-center justify-center text-xl font-semibold"
      >
        {{ product.title }}
      </div>
    </div>
  </section>
</template>

