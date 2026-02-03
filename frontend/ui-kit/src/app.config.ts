export const ibgAppConfig = {
  ui: {
    colors: {
      black: "black",
      white: "white",
      error: "error",
      secondary: "secondary",
    },
    textarea: {
      variants: {
        variant: {
          outline: `
        !ring-0
        !focus:ring-0
        !focus-visible:ring-0
      `,
        },
        size: {
          md: {
            base: "p-0 tracking-tight max-lg:tracking-tighter max-lg:text-xs text-base placeholder:text-secondary font-medium",
          },
        },
      },
    },
    button: {
      compoundVariants: [
        {
          color: "black",
          variant: "link",
          class:
            "text-black hover:text-secondary disabled:text-secondary active:text-black cursor-pointer text-base tracking-tight max-lg:tracking-tighter  max-lg:text-xs leading-none font-medium p-0 bg-transparent active:bg-transparent hover:bg-transparent",
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
          "placeholder:text-secondary tracking-tight max-lg:tracking-tighter max-lg:!text-xs !text-base !font-medium !p-0 rounded-none leading-none",
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
        root: "w-max",
        base: "bg-secondary-500 ring-0 cursor-pointer",
        item: `flex items-center text-black not-has-[button[aria-checked="true"]]:text-secondary-500`,
        label: "text-inherit font-medium text-4xl tracking-tight max-lg:tracking-tighter cursor-pointer",
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
            base: "size-6.25",
          },
        },
      },
      defaultVariants: {
        color: "black",
        variant: "list",
        size: "xl",
      },
    },
    fileUpload: {
      slots: {
        root: "cursor-pointer",
        base: "border-none rounded-none bg-gray-500",
        avatar: "bg-transparent text-6xl",
        fileLeadingAvatar: "bg-secondary-500 text-6xl",
      },
      variants: {
        dropzone: {
          true: "border-none",
        },
        layout: {
          grid: {
            fileLeadingAvatar: "rounded-none",
          },
        },
      },
      compoundVariants: [
        {
          interactive: true,
          disabled: false,
          class: "hover:!bg-gray-500 hover:opacity-70",
        },
      ],
    },
    card: {
      slots: {
        root: "rounded-none",
        body: "p-0 sm:p-0",
        footer: "p-0 sm:px-0 !pl-5 !pt-5 tracking-tight max-lg:tracking-tighter max-lg:text-xs text-base text-black font-medium",
      },
      variants: {
        variant: {
          outline: "ring-0",
        },
      },
    },
  },
};
