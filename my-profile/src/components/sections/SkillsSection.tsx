import type { ProfileData } from '../../types/profile'
import { SectionHeading } from '../ui/SectionHeading'

type SkillsSectionProps = {
  profile: ProfileData
}

export function SkillsSection({ profile }: SkillsSectionProps) {
  return (
    <section className="px-6 py-16 sm:px-10 lg:px-14">
      <div className="mx-auto max-w-7xl space-y-10">
        <SectionHeading
          eyebrow="Skills"
          title="Balanced across frameworks, backend logic, and production support."
          description="Your resume shows range across Microsoft technologies, Laravel, relational databases, and the practical work of keeping internal systems dependable."
        />

        <div className="grid gap-6 lg:grid-cols-3">
          {profile.skillGroups.map((group) => (
            <article
              key={group.title}
              className="rounded-[2rem] border border-stone-200 bg-white p-8 shadow-[0_18px_50px_-30px_rgba(41,37,36,0.3)]"
            >
              <p className="text-sm font-semibold uppercase tracking-[0.35em] text-stone-500">
                {group.title}
              </p>
              <ul className="mt-6 space-y-4">
                {group.items.map((item) => (
                  <li
                    key={item}
                    className="border-b border-stone-200 pb-4 text-base text-stone-700 last:border-b-0 last:pb-0"
                  >
                    {item}
                  </li>
                ))}
              </ul>
            </article>
          ))}
        </div>
      </div>
    </section>
  )
}
