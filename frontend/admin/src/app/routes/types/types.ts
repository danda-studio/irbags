export type NavigationItemsType = 'главная' | 'товары' | 'фильтры';

export const routesMap: Record<NavigationItemsType, string> = {
    главная: '/',
    товары: '/products',
    фильтры: '/filters',
}
