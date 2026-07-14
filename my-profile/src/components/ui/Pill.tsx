type PillProps = {
  children: string
}

export function Pill({ children }: PillProps) {
  return (
    <span className="rounded-full border border-stone-300/80 bg-white/85 px-3 py-1 text-xs font-medium uppercase tracking-[0.22em] text-stone-700 shadow-sm">
      {children}
    </span>
  )
}
