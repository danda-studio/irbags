<script lang="ts" setup>
const bannerKeys = {
  main: "bannerMain",
  banner1: "banner1",
  banner2: "banner2",
  banner3: "banner3",
  footer: "bannerFooter",
};
</script>

<template>
  <div class="h-screen max-lg:h-225">
    <BannerFeature :banner-key="bannerKeys.main" class="w-full h-full" />
    <div class="flex h-screen max-lg:h-225">
      <BannerFeature :banner-key="bannerKeys.banner1" class="w-full h-full" />
      <BannerFeature :banner-key="bannerKeys.banner2" class="w-full h-full" />
    </div>
    <BannerFeature :banner-key="bannerKeys.banner3" class="w-full h-225 max-lg:h-180" />
    <BannerFeature :banner-key="bannerKeys.footer" class="w-full h-full" />
  </div>
</template>
