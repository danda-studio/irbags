<script setup lang="ts">
type Product = {
  id: number
  title: string
  price: number
}

const products: Product[] = Array.from({ length: 16 }, (_, i) => ({
  id: i + 1,
  title: `Сумка Kelly ${i + 1}`,
  price: 69,
}))
</script>

<template>
  <section class="pt-220 :lg-pt-145 w-screen px-0 pb-40">
    <div class="grid grid-cols-4 gap-x-0 gap-y-40 :lg-gap-y-30">
      <IBGCard
          v-for="product in products"
          :key="product.id"
          class="mt-5"
      >
        <template #default>
          <div class="bg-secondary-500 w-120 h-170.75"/>
        </template>

        <template #footer>
          <div>{{ product.title }}</div>
          <div>{{ product.price }} €</div>
        </template>
      </IBGCard>
    </div>
  </section>
</template>
