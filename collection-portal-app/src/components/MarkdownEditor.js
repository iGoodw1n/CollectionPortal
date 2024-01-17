import '@mdxeditor/editor/style.css'
import { BlockTypeSelect, BoldItalicUnderlineToggles, DiffSourceToggleWrapper, ListsToggle, MDXEditor, UndoRedo, diffSourcePlugin, headingsPlugin, linkPlugin, listsPlugin, markdownShortcutPlugin, quotePlugin, thematicBreakPlugin, toolbarPlugin } from '@mdxeditor/editor'

const MarkdownEditor = ({ text, innerRef }) => {
  return (
    <div style={{ backgroundColor: 'white' }}>
      <MDXEditor
        ref={innerRef}
        markdown={text}
        plugins={[
          headingsPlugin(),
          listsPlugin(),
          quotePlugin(),
          thematicBreakPlugin(),
          linkPlugin(),
          markdownShortcutPlugin(),
          diffSourcePlugin(),
          toolbarPlugin({
            toolbarContents: () => (
              <>
                {' '}
                <UndoRedo />
                <BoldItalicUnderlineToggles />
                <BlockTypeSelect />
                <ListsToggle />
                <DiffSourceToggleWrapper />
              </>
            )
          })
        ]} />
    </div>
  )

}

export default MarkdownEditor