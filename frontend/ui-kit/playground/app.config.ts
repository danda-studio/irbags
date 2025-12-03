export default defineAppConfig({
  ui: {
    colors: {
      black: "black",
      white: "white",
      error: "error",
      secondary: "secondary",
    },
    button: {
      compoundVariants: [
        {
          color: "black",
          variant: "link",
          class:
            "text-black hover:text-secondary disabled:text-secondary active:text-black cursor-pointer text-xl leading-none font-medium p-0 bg-transparent active:bg-transparent hover:bg-transparent",
        },
      ],
      defaultVariants: {
        color: "black",
        variant: "link",
      },
    },
    input: {
      compoundVariants: [
        {
          color: "black",
          variant: "none",
          class:
            "placeholder:text-secondary text-xl text-black leading-none font-medium p-0 rounded-none",
        },
      ],
      defaultVariants: {
        color: "black",
        variant: "none",
      },
    },
  },
});
