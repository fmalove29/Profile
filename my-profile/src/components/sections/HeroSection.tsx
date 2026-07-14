import type { ProfileData } from '../../types/profile'
import { Pill } from '../ui/Pill'

type HeroSectionProps = {
  profile: ProfileData
}

export function HeroSection({ profile }: HeroSectionProps) {
  return (
    <section className="relative overflow-hidden px-6 pb-16 pt-8 sm:px-10 lg:px-14 lg:pb-24 lg:pt-12">
      <div className="absolute inset-x-0 top-0 -z-10 h-[34rem] bg-[radial-gradient(circle_at_top_left,_rgba(245,158,11,0.18),_transparent_38%),radial-gradient(circle_at_top_right,_rgba(59,130,246,0.14),_transparent_28%),linear-gradient(180deg,_#f8f5ef_0%,_#f5f5f4_65%,_#f1f5f9_100%)]" />

      <div className="mx-auto max-w-7xl">
        <div className="mb-10 flex flex-wrap gap-3">
          <Pill>{profile.availability}</Pill>
          <Pill>{profile.location}</Pill>
        </div>

        <div className="grid items-center gap-12 lg:grid-cols-[1.15fr_0.85fr]">
          <div className="space-y-8">
            <div className="space-y-5">
              <p className="text-sm font-semibold uppercase tracking-[0.5em] text-stone-500">
                Personal Portfolio
              </p>
              <h1 className="max-w-4xl text-5xl font-semibold leading-none tracking-[-0.05em] text-stone-950 sm:text-6xl lg:text-7xl">
                {profile.name}
              </h1>
              <p className="text-lg font-medium uppercase tracking-[0.35em] text-stone-600 sm:text-xl">
                {profile.title}
              </p>
              <p className="max-w-2xl text-lg leading-8 text-stone-700">
                {profile.intro}
              </p>
            </div>

            <div className="grid gap-4 sm:grid-cols-2">
              {profile.quickStats.map((item) => (
                <div
                  key={item}
                  className="rounded-3xl border border-white/60 bg-white/70 p-5 shadow-[0_20px_60px_-30px_rgba(41,37,36,0.35)] backdrop-blur"
                >
                  <p className="text-sm font-semibold uppercase tracking-[0.28em] text-stone-500">
                    Focus
                  </p>
                  <p className="mt-3 text-lg font-medium text-stone-900">
                    {item}
                  </p>
                </div>
              ))}
            </div>
          </div>

          <div className="relative mx-auto w-full max-w-md">
            <div className="absolute -left-8 top-12 hidden h-28 w-28 rounded-full bg-amber-300/40 blur-2xl sm:block" />
            <div className="absolute -right-4 bottom-16 h-32 w-32 rounded-full bg-sky-300/30 blur-2xl" />

            <div className="relative rounded-[2rem] border border-white/70 bg-white/80 p-4 shadow-[0_30px_80px_-35px_rgba(28,25,23,0.55)] backdrop-blur">
              <img
                src={profile.heroImage}
                alt={`${profile.name} formal portrait`}
                className="h-[30rem] w-full rounded-[1.6rem] object-cover object-top"
              />

              <div className="absolute -bottom-10 -left-6 w-40 rounded-[1.5rem] border border-white/80 bg-stone-950 p-3 text-white shadow-2xl">
                <img
                  src={profile.accentImage}
                  alt={`${profile.name} graduation portrait`}
                  className="h-28 w-full rounded-xl object-cover object-top"
                />
                <p className="mt-3 text-xs font-semibold uppercase tracking-[0.3em] text-stone-400">
                  Education
                </p>
                <p className="mt-1 text-sm leading-6 text-stone-100">
                  BS Information Technology graduate
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  )
}
