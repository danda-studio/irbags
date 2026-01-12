import { ref, watch } from 'vue'
import { useRouter } from 'vue-router'
import { routesMap } from '~/app/routes/types/types'
import type { NavigationItemsType } from '~/app/routes/types/types'

export const useNavigation = () => {
    const router = useRouter()
    const selected = ref<NavigationItemsType>('главная')

    watch(selected, (value, oldValue) => {
        if (value && value !== oldValue) router.push(routesMap[value])
    })

    const navigationItems = Object.keys(routesMap)

    return { selected, navigationItems }
}
