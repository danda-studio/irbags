<script setup lang="ts">
import type { productData } from "./interfaces";

/** Данные формы */
const data = ref<productData>({
    detailsDescription: "",
    discount: "",
    name: "",
    price: "",
    shortDescription: "",
    size: "",
});
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

const isStrikethrough = computed(() => data.value.discount && data.value.price)

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
            <div class="flex flex-col justify-between w-123.75 pl-5 pr-15">
                <div>
                    <div class="mt-55 max-lg:mt-43.5">
                        <IBGTextarea v-model="data.detailsDescription" :maxrows="3"
                            placeholder="описание продукта, материалы, фурнитура и прочее" autoresize class="w-full" />
                    </div>
                    <div class="mt-0.5 max-lg:mt-2.5">
                        <IBGResizebleInput v-model="data.size"
                            style-label="inline-block max-w-113.75 max-lg:max-w-72.75 overflow-hidden"
                            placeholder="размер" />
                    </div>
                </div>
                <div class="flex flex-col mb-5.5 gap-1.25 text-base max-lg:text-x">
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
            <div class="w-123.75 pl-5 pr-15">
                <div class="mt-51 max-lg:mt-41">
                    <IBGResizebleInput v-model="data.name"
                        style-label="!text-4xl max-lg:text-3xl inline-block max-w-113.75 max-lg:max-w-72.75 overflow-hidden !text-black-500"
                        :config="{
                            ui: {
                                base: ['!text-4xl max-lg:text-3xl! placeholder:text-black-500!'],
                            },
                        }" placeholder="название" />
                    <div class="flex gap-5 max-lg:gap-3 mt-2.5 max-lg:mt-1.5">
                        <IBGResizebleInput v-model="data.price" placeholder="сумма"
                            style-label="!text-4xl !max-lg:text-3xl inline-block max-w-54.25 max-lg:max-w-35 overflow-hidden"
                            :config="{
                                ui: {
                                    base: ['!text-4xl max-lg:text-3xl! placeholder:text-black-500!', isStrikethrough ? 'line-through' : ''],
                                },
                            }" @input="data.price = data.price.replace(/\D/g, '')" />
                        <IBGResizebleInput v-model="data.discount" placeholder="скидка"
                            style-label="!text-4xl !max-lg:text-3xl inline-block max-w-54.25 max-lg:max-w-35 overflow-hidden"
                            :config="{
                                ui: {
                                    base: ['!text-4xl max-lg:text-3xl!'],
                                },
                            }" @input="data.discount = data.discount.replace(/\D/g, '')" />
                    </div>
                    <IBGTextarea v-model="data.shortDescription" :maxrows="3" placeholder="краткое описание товара"
                        autoresize class="w-full mt-7.5 max-lg:mt-3.5" />
                    <IBGRadioGroup v-model="value" class="mt-2.25 max-lg:mt-1.25" :items="colorIndexes"
                        :ui="{ container: 'hidden', wrapper: 'ml-0 max-lg:mt-1', fieldset: 'max-h-145 overflow-auto gap-5.5', label: 'text-base max-lg:text-xs' }">
                        <template #label="{ item }">
                            <IBGInput v-model="colors[item.value]" placeholder="добавить цвет" :ui="{
                                base: ['placeholder:text-black-500!']
                            }" @focus="value = item.value" @blur="filterColors" />
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
