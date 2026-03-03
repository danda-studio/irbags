<script setup lang="ts">
interface Product {
  id: number;
  title: string;
  price: number;
}

const products: Product[] = Array.from({ length: 16 }, (_, i) => ({
  id: i + 1,
  title: `cумка kelly ${i + 1}`,
  price: 69,
}));
</script>

<template>
  <section class="mt-65 max-lg:mt-45 w-screen px-0 pb-2">
    <div class="grid grid-cols-4 gap-x-0 gap-y-10 max-lg:gap-y-8">
      <IBGCard v-for="product in products" :key="product.id">
        <template #default>
          <div class="bg-secondary-500 w-90 h-124.75 lg:w-120 lg:h-170.75" />
        </template>

        <template #footer>
          <div class="flex flex-col gap-1">
            <div>{{ product.title }}</div>
            <div>{{ product.price }} €</div>
          </div>
        </template>
      </IBGCard>
    </div>
  </section>
</template>
