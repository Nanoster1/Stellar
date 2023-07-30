/* eslint-env node */
require("@rushstack/eslint-patch/modern-module-resolution");

module.exports = {
  root: true,
  extends: [
    "plugin:vue/vue3-recommended",
    "eslint:recommended",
    "@vue/eslint-config-prettier/skip-formatting"
  ],
  parserOptions: {
    ecmaVersion: "latest"
  },
  rules: {
    "vue/first-attribute-linebreak": ["error", {
      "singleline": "ignore",
      "multiline": "below"
    }],
    "vue/attributes-order": ["error", {
      "order": [
        "DEFINITION",
        "LIST_RENDERING",
        "CONDITIONALS",
        "RENDER_MODIFIERS",
        "GLOBAL",
        "UNIQUE",
        "SLOT",
        "TWO_WAY_BINDING",
        "OTHER_DIRECTIVES",
        "ATTR_STATIC",
        "ATTR_DYNAMIC",
        "ATTR_SHORTHAND_BOOL",
        "EVENTS",
        "CONTENT"
      ],
      "alphabetical": false
    }],
    "vue/order-in-components": ["error", {
      "order": [
        "el",
        "name",
        "key",
        "parent",
        "functional",
        "delimiters",
        "comments",
        "components",
        "directives",
        "filters",
        "extends",
        "mixins",
        "provide",
        "inject",
        "ROUTER_GUARDS",
        "layout",
        "middleware",
        "validate",
        "scrollToTop",
        "transition",
        "loading",
        "inheritAttrs",
        "model",
        "props",
        "propsData",
        "emits",
        "setup",
        "asyncData",
        "data",
        "fetch",
        "head",
        "computed",
        "watch",
        "watchQuery",
        "LIFECYCLE_HOOKS",
        "methods",
        "template",
        "render",
        "renderError"
      ]
    }],
    "vue/no-irregular-whitespace": ["error", {
      "skipStrings": true,
      "skipComments": false,
      "skipRegExps": false,
      "skipTemplates": false,
      "skipHTMLAttributeValues": false,
      "skipHTMLTextContents": false
    }],
    "vue/component-definition-name-casing": ["error", "PascalCase"],
    "vue/match-component-file-name": ["error", {
      "extensions": ["vue"],
      "shouldMatchCase": true
    }],
    "vue/component-name-in-template-casing": ["error", "kebab-case", {
      "registeredComponentsOnly": true,
      "ignores": []
    }],
    "vue/custom-event-name-casing": ["error",
      "camelCase",
      {
        "ignores": []
      }
    ],
    "vue/new-line-between-multi-line-property": ["error", {
      "minLineOfMultilineProperty": 2
    }],
    "vue/next-tick-style": ["error", "promise"],
    "vue/v-bind-style": ["error", "shorthand"],
    "vue/no-empty-component-block": ["error"],
    "vue/require-name-property": ["error"],
    "vue/v-on-event-hyphenation": ["error", "always", {
      "autofix": true,
      "ignore": []
    }]
  }
};