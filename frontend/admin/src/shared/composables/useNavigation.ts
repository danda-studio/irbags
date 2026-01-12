import { ref, watch } from 'vue'
import { useRouter } from 'vue-router'

export type NavigationItemsType = 'главная' | 'товары' | 'фильтры';

export const routesMap: Record<NavigationItemsType, string> = {
    главная: '/',
    товары: '/products',
    фильтры: '/filters',
}


export const useNavigation = () => {
    const router = useRouter()
    const selected = ref<NavigationItemsType>('главная')

    watch(selected, (value, oldValue) => {
        if (value && value !== oldValue) router.push(routesMap[value])
    })

    const navigationItems = Object.keys(routesMap)

    return { selected, navigationItems }
}
