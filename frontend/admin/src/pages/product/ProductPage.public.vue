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
const items = ref(["System", "Light", "Dark"]);
const value = ref("0");
const colors = ref<Record<string, string>>({});

const colorIndexes = computed(() => {
    if (!Object.keys(colors.value).length)
        return [{ value: "0" }];
    const items = Object.keys(colors.value).map(item => ({ value: item }));
    if (items.at(-1)?.value) {
        items.push({ value: String(items.length) });
    }
    return items;
});

function filterColors() {
    if (Object.keys(colors.value).length === 1)
        return;
    colors.value = Object.entries(colors.value).reduce((acc, [key, value]) => {
        if (value)
            acc[key] = value;
        return acc;
    }, {} as Record<string, string>);
}
</script>

<template>
    <div>
        <div class="flex">
            <div class="flex flex-col justify-between w-123.75 pl-5 pr-5">
                <div>
                    <div class="mt-55">
                        <IBGTextarea v-model="data.detailsDescription"
                            placeholder="описание продукта, материалы, фурнитура и прочее" autoresize class="w-full" />
                    </div>
                    <IBGResizebleInput v-model="data.size" placeholder="размер" class="mt-7.5" />
                </div>
                <div>
                    <div>сумки</div>
                    <div>ремни</div>
                    <div>платки</div>
                    <div>подвесы</div>
                    <div>брелки</div>
                    <div>обложки</div>
                    <div>визитницы</div>
                </div>
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
                    <IBGRadioGroup class="mt-12.5" v-model="value" :items="colorIndexes"
                        :ui="{ wrapper: 'ml-2', fieldset: 'gap-5.5', label: 'text-base max-lg:text-xs' }">
                        <template #label="{ item }">
                            <IBGInput v-model="colors[item.value]" placeholder="добавить цвет"
                                @focus="value = item.value" @blur="filterColors" />
                        </template>
                    </IBGRadioGroup>
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
