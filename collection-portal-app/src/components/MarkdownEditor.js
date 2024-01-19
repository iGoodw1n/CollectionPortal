import '@mdxeditor/editor/style.css'
import { BlockTypeSelect, BoldItalicUnderlineToggles, DiffSourceToggleWrapper, ListsToggle, MDXEditor, UndoRedo, diffSourcePlugin, headingsPlugin, linkPlugin, listsPlugin, markdownShortcutPlugin, quotePlugin, thematicBreakPlugin, toolbarPlugin } from '@mdxeditor/editor'
import { useContext } from 'react'
import ThemeContext from '../contexts/ThemeContext'

const MarkdownEditor = ({ label, text, innerRef }) => {

  const [theme] = useContext(ThemeContext)
  return (
    <>
      <label className='d-block text-center m-3 fs-3'>{label}</label>
      <div className='border'>
        <MDXEditor
          className={theme === 'dark' ? "dark-theme dark-editor" : ''}
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
    </>

  )

}

export default MarkdownEditor