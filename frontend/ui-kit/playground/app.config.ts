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
      slots: {
        base: [
          "placeholder:text-secondary !text-xl !font-medium !p-0 rounded-none leading-none",
        ],
      },
      compoundVariants: [
        {
          color: "black",
          variant: "none",
          class: "text-black",
        },
        {
          color: "error",
          variant: "none",
          class: "text-error",
        },
      ],
      defaultVariants: {
        color: "black",
        variant: "none",
      },
    },
    radioGroup: {
      slots: {
        base: "bg-secondary-500 ring-0 cursor-pointer",
        item: `flex items-center text-black not-has-[button[aria-checked="true"]]:text-error`,
        label: "text-inherit font-medium text-4xl cursor-pointer",
        indicator: "after:bg-transparent cursor-pointer",
      },
      variants: {
        indicator: {
          start: {
            wrapper: "ml-2.5",
          },
        },
        size: {
          xl: {
            base: "size-big",
          },
        },
      },
      defaultVariants: {
        color: "black",
        variant: "list",
        size: "xl",
      },
    },
  },
});
