import { useRouter } from 'vue-router'

export type NavigationItemsType = 'главная' | 'товары' | 'фильтры';

export const routesMap: Record<NavigationItemsType, string> = {
    главная: '/',
    товары: '/products',
    фильтры: '/filters',
}


export function useNavigation() {
    const router = useRouter()

    const selected = computed<NavigationItemsType>({
        get() {
            const entry = Object.entries(routesMap)
                .find(([_, path]) => path === router.currentRoute.value.path)

            return (entry?.[0] as NavigationItemsType) ?? 'главная'
        },
        set(value) {
            router.push(routesMap[value]);
        },
    });


    return { selected }
}
