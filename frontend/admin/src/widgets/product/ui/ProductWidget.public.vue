<script setup lang="ts">
interface Product {
  id: number;
  title: string;
  price: number;
}

const products: Product[] = Array.from({ length: 16 }, (_, i) => ({
  id: i + 1,
  title: `Сумка Kelly ${i + 1}`,
  price: 69,
}));
</script>

<template>
  <section class="mt-55 w-screen px-0 pb-2">
    <div class="grid grid-cols-4 gap-x-0 gap-y-5">
      <IBGCard v-for="product in products" :key="product.id">
        <template #default>
          <div class="bg-secondary-500 w-90 h-138.75 lg:w-120 lg:h-170.75" />
        </template>

        <template #footer>
          <div class="flex flex-col gap-1.25">
            <div>{{ product.title }}</div>
            <div>{{ product.price }} €</div>
          </div>
        </template>
      </IBGCard>
    </div>
  </section>
</template>
