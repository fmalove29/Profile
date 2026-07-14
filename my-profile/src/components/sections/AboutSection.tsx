import type { ProfileData } from '../../types/profile'
import { SectionHeading } from '../ui/SectionHeading'

type AboutSectionProps = {
  profile: ProfileData
}

export function AboutSection({ profile }: AboutSectionProps) {
  return (
    <section className="px-6 py-16 sm:px-10 lg:px-14">
      <div className="mx-auto grid max-w-7xl gap-10 lg:grid-cols-[0.8fr_1.2fr]">
        <SectionHeading
          eyebrow="Profile"
          title="A developer focused on maintainable systems and steady delivery."
          description="The portfolio takes its rhythm from the reference site, but the story, content, and visual identity are fully aligned with your own background."
        />

        <div className="space-y-6 rounded-[2rem] border border-stone-200 bg-white p-8 shadow-[0_20px_60px_-30px_rgba(41,37,36,0.25)]">
          <p className="text-lg leading-8 text-stone-700">{profile.summary}</p>
          <div className="grid gap-4 sm:grid-cols-3">
            <div className="rounded-2xl bg-stone-100 p-4">
              <p className="text-xs font-semibold uppercase tracking-[0.3em] text-stone-500">
                Current Base
              </p>
              <p className="mt-2 text-base font-medium text-stone-900">
                {profile.location}
              </p>
            </div>
            <div className="rounded-2xl bg-stone-100 p-4">
              <p className="text-xs font-semibold uppercase tracking-[0.3em] text-stone-500">
                Core Stack
              </p>
              <p className="mt-2 text-base font-medium text-stone-900">
                Laravel, .NET, SQL
              </p>
            </div>
            <div className="rounded-2xl bg-stone-100 p-4">
              <p className="text-xs font-semibold uppercase tracking-[0.3em] text-stone-500">
                Work Style
              </p>
              <p className="mt-2 text-base font-medium text-stone-900">
                Agile and collaborative
              </p>
            </div>
          </div>
        </div>
      </div>
    </section>
  )
}
