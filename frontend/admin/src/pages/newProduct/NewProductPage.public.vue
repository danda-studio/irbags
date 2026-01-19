<template>
    <div>
        <div class="flex justify-between">
            <div class="flex flex-col justify-between mt-43.5 ml-5 pr-5 w-full max-w-123.75 min-w-123.75">
                <div class="flex flex-col gap-7.5">
                    <IBGInput placeholder="описание продукта, материалы, фурнитура и прочее" class="w-full" />
                    <IBGInput placeholder="размер" class="w-full" />
                </div>
                <div class="mb-5">
                    <IBGInput placeholder="тег" class="w-full" />
                </div>
            </div>
            <div class="h-screen max-lg:h-225">
                <IBGFileInput class="w-232.5 h-full" />
            </div>
            <div class="mt-42 pl-5 mr-5 w-full max-w-123.75 min-w-123.75">
                <IBGInput placeholder="название" class="w-full" :ui="{
                    base: 'text-4xl! max-lg:text-3xl!'
                }" />
                <div class="flex gap-5 mb-5.5 w-59.75 max-lg:w-51.75">
                    <IBGInput placeholder="сумма" class="w-full" :ui="{
                        base: 'text-4xl! max-lg:text-3xl!'
                    }" />
                    <IBGInput placeholder="скидка" class="w-full" :ui="{
                        base: 'text-4xl! max-lg:text-3xl!'
                    }" />
                </div>
                <IBGInput placeholder="краткое описание товара" class="w-full mb-10.5" />
                <IBGInput placeholder="добавить цвет" class="w-full" />
            </div>
        </div>
        <div class="flex justify-between">
            <div class="flex flex-col justify-between ml-5 pr-5 w-full max-w-123.75 min-w-123.75" />
            <div class="h-screen max-lg:h-225">
                <IBGFileInput class="w-232.5 h-full " />
            </div>
            <div class="pl-5 mr-5 w-full max-w-123.75 min-w-123.75" />
        </div>
        <div class="flex h-screen max-lg:h-225">
            <IBGFileInput class="w-full h-full " />
            <IBGFileInput class="w-full h-full" />
        </div>
        <div class="flex h-screen max-lg:h-225">
            <IBGFileInput class="w-full h-full " />
            <IBGFileInput class="w-full h-full " />
        </div>
    </div>
</template>