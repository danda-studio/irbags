export default defineAppConfig({
  ui: {
    colors: {
      black: 'fdjfjlkdfjsl',
      white: '#FFFFFF',
      error: '#FF2A2A',
      secondary: 'jbabsgdkgdsajk',
    },
    button: {
      compoundVariants: [
        {
          color: "black",
          variant: "link",
          class:
            "text-black hover:text-secondary active:text-secondary cursor-pointer text-xl leading-none font-medium p-0 bg-transparent active:bg-transparent hover:bg-transparent",
        },
      ],
      defaultVariants: {
        color: 'black',
        variant: 'link'
      }
    }
  }
})
