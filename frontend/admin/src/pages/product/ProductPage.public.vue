<script setup lang="ts">
import type { productData } from "./interfaces";

/** Данные формы */
const data = ref<productData>({
    detailsDescription: '',
    discount: '',
    name: '',
    price: '',
    shortDescription: '',
    size: ''
});
</script>

<template>
    <div>
        <div class="flex">
            <div class="w-123.75 pl-5 pr-5">
                <div class="mt-55">
                    <IBGTextarea v-model="data.detailsDescription"
                        placeholder="описание продукта, материалы, фурнитура и прочее" autoresize class="w-full" />
                </div>
                <IBGResizebleInput v-model="data.size" placeholder="размер" class="mt-7.5" />
            </div>
            <div>
                <IBGFileInput class="w-232.5 h-screen max-lg:w-172.5 max-lg:h-225" />
            </div>
            <div class="w-123.75 pl-5 pr-5">
                <div class="mt-55">
                    <IBGResizebleInput v-model="data.name" placeholder="название" />
                    <div>
                        <IBGResizebleInput v-model="data.price" placeholder="сумма" />
                        <IBGResizebleInput v-model="data.discount" placeholder="скидка" />
                    </div>
                </div>
            </div>
        </div>
        <div class="flex">
            <div class="w-123.75 pl-5 pr-5" />
            <div>
                <IBGFileInput class="w-232.5 h-screen max-lg:w-172.5 max-lg:h-225" />
            </div>
            <div class="w-123.75 pl-5 pr-5" />
        </div>
        <div class="flex">
            <IBGFileInput class="w-full h-screen max-lg:w-180 max-lg:h-225" />
            <IBGFileInput class="w-full h-screen max-lg:w-180 max-lg:h-225" />
        </div>
        <div class="flex">
            <IBGFileInput class="w-full h-screen max-lg:w-180 max-lg:h-225" />
            <IBGFileInput class="w-full h-screen max-lg:w-180 max-lg:h-225" />
        </div>
    </div>
</template>
